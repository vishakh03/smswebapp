pipeline {
    agent any

    triggers {
    // Fires as soon as GitHub sends a push event
    githubPush()
    }

    environment {
        PATH = "C:\\Windows\\System32;C:\\Program Files\\dotnet;${env.PATH}"
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test --logger:"junit;LogFilePath=TestResults/test-results.xml"'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish --configuration Release --no-build --output publish'
            }
        }

        stage('aetifacts') {
            steps{
                archiveArtifacts artifacts: 'publish/**', fingerprint: true
            }
        }
    }

   post {
    always {
        script {
            if (fileExists('TestResults/test-results.xml')) {
                junit 'TestResults/test-results.xml'
            } else {
                echo 'No test report files found.'
            }
        }
    }
   }
    
}
