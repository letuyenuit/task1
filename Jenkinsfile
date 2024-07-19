pipeline{
    agent any
    environment {
        // SONAR_PROJECT_KEY= credentials('sonar-project-key')
        // SONAR_PROJECT_NAME = credentials('sonar-project-name')
    }
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
                        sh "${scannerHome}/bin/sonar-scanner"
                    }
                }
            }
        }
    }
}