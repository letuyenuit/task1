pipeline{
    agent any
    environment {
        DOCKER_TOKEN = credentials('dockerhub')
    }
    parameters {
        choice choices: ['Baseline', 'APIS', 'Full'],
            description: 'Type of scan that is going to perform inside the container',
            name: 'SCAN_TYPE'
            
        string defaultValue: 'http://192.168.56.90:5000',
            description: 'Target URL to scan',
            name: 'TARGET'
            
        booleanParam defaultValue: true,
            description: 'Parameter to know if you want to generate a report.',
            name: 'GENERATE_REPORT'
    }
    stages {
        stage('clean workspace'){
            steps{
                cleanWs()
            }
        }
        stage('Remove exists container'){
            steps{
                sh 'docker rm owasp'
                sh 'docker compose down'
            }
        }
        stage('Checkout from Git'){
            steps{
                git branch: 'master', url: 'https://github.com/letuyenuit/task1.git'
            }
        }
        stage('Code Analysis') {
            environment {
                scannerHome = tool 'Sonar'
                sonar_token= credentials('sonar-token')
                sonar_organize = credentials('sonar-og')
                sonar_projectKey = credentials('sonar-project')
            }
            steps {
                script {
                    withSonarQubeEnv('Sonar') {
                        sh '''${scannerHome}/bin/sonar-scanner \
                            -Dsonar.host.url=https://sonarcloud.io \
                            -Dsonar.token=${sonar_token} \
                            -Dsonar.organization=${sonar_organize} \
                            -Dsonar.projectKey=${sonar_projectKey} \
                            -Dsonar.sources=. \
                            -Dsonar.junit.reportsPath=. \
                            -Dsonar.jacoco.reportsPath=.
                        '''
                    }
                }
            }
        }
        stage("Quality Gate"){
            steps {
                script {
                    timeout(time: 1, unit: 'HOURS') {
                    def qg = waitForQualityGate()
                    if (qg.status != 'OK') {
                        error "Pipeline aborted due to quality gate failure: ${qg.status}"
                        }
                    }
                }
            }
        }

        stage('OWASP FS SCAN') {
            steps {
                dependencyCheck additionalArguments: '--scan ./ --disableYarnAudit --disableNodeAudit --nvdApiKey ac7675f4-4c87-4307-9818-921ac675e708 -out ./', odcInstallation: 'DP-Check'
            }
        }
        stage('TRIVY FS SCAN') {
            steps {
                sh "trivy fs . > trivyfs.txt"
            }
        }
        stage('Build and push to dockerhub'){
            steps{
                sh 'echo ${DOCKER_TOKEN} | docker login -u letuyenuit212 --password-stdin'
                sh 'docker build -t letuyenuit212/devsecops:v1 .'
                sh 'docker push letuyenuit212/devsecops:v1'
            }
        }

        stage("TRIVY"){
            steps{
                sh "trivy image letuyenuit212/devsecops:v1 > trivyimage.txt"
            }
        }
        
        stage('Deploy to container'){
            steps{
                sh 'docker compose up -d'
            }
        }

        stage('Setting up OWASP ZAP docker container') {
            steps {
                echo 'Pulling up last OWASP ZAP container --> Start'
                sh 'docker pull ghcr.io/zaproxy/zaproxy:stable'
                echo 'Pulling up last VMS container --> End'
                echo 'Starting container --> Start'
                sh 'docker run -dt --name owasp ghcr.io/zaproxy/zaproxy:stable /bin/bash '
            }
        }

        stage('Prepare wrk directory') {
            when {
                environment name : 'GENERATE_REPORT', value: 'true'
            }
            steps {
                script {
                    sh '''
                             docker exec owasp \
                             mkdir /zap/wrk
                         '''
                }
            }
        }

        stage('Scanning target on owasp container') {
            steps {
                script {
                    scan_type = "${params.SCAN_TYPE}"
                    echo "----> scan_type: $scan_type"
                    target = "${params.TARGET}"
                    if (scan_type == 'Baseline') {
                        sh """
                             docker exec owasp \
                             zap-baseline.py \
                             -t $target \
                             -r report.html \
                             -I
                         """
                    }
                     else if (scan_type == 'APIS') {
                        sh """
                             docker exec owasp \
                             zap-api-scan.py \
                             -t $target \
                             -r report.html \
                             -I
                         """
                     }
                     else if (scan_type == 'Full') {
                        sh """
                             docker exec owasp \
                             zap-full-scan.py \
                             -t $target \
                             -r report.html \
                             -I
                         """
                     }
                     else {
                        echo 'Something went wrong...'
                     }
                }
            }
        }
        stage('Copy Report to Workspace') {
            steps {
                script {
                    sh '''
                         docker cp owasp:/zap/wrk/report.html ${WORKSPACE}/report.html
                     '''
                }
            }
        }
    }
}