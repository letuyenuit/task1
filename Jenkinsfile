pipeline{
    agent any
    stages {
        stage('clean workspace'){
            steps{
                cleanWs()
            }
        }
        stage('Checkout from Git'){
            steps{
                git branch: 'main', url: 'https://github.com/letuyenuit/task1.git'
            }
        }
        stage('Code Analysis') {
            environment {
                scannerHome = tool 'Sonar'
            }
            steps {
                script {
                    withSonarQubeEnv('Sonar') {
                        sh '''${scannerHome}/bin/sonar-scanner 
                            -Dsonar.host.url=https://sonarcloud.io
                            -Dsonar.login=b1a11cbe4aca5e7071b4fde90518b1374c4c37fd
                            -Dsonar.organization=doanchuyennghanh
                            -Dsonar.projectKey=doanchuyennghanh_devsecops
                            -Dsonar.sources=Controllers/ '''
                    }
                }
            }
        }
    }
}