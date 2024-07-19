pipeline{
    agent any
    environment {
        DOCKER_TOKEN = credentials('dockerhub')
    }
    stages {
        stage('clean workspace'){
            steps{
                cleanWs()
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
                sh 'docker-compose up -d'
            }
        }
    }
    post {
        always {
            emailext attachLog: true,
                subject: "'${currentBuild.result}'",
                body: "Project: ${env.JOB_NAME}<br/>" +
                    "Build Number: ${env.BUILD_NUMBER}<br/>" +
                    "URL: ${env.BUILD_URL}<br/>",
                to: 'letuyenkhtn212@gmail.com',
                attachmentsPattern: 'trivyfs.txt,trivyimage.txt'
            }
    }
}