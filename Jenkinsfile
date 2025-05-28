@Library('my-shared-library') _

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
                //bat 'dotnet test --configuration Release --no-restore --no-build --logger:"junit;LogFilePath=smswebapp.tests/TestResults/test-results.xml"'

                //multi branch pipeline
                bat 'dotnet test --configuration Release --no-restore --no-build --logger:"junit;LogFilePath=smswebapp.tests/smswebapp.tests/TestResults/test-results.xml"'
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
            //if (fileExists('smswebapp.tests/TestResults/test-results.xml')) {
                //junit 'smswebapp.tests/TestResults/test-results.xml'
                //junit '**/TestResults/*.xml'

            //Multibranch pipeline
            if (fileExists('smswebapp.tests/smswebapp.tests/TestResults/test-results.xml')) {
                junit 'smswebapp.tests/smswebapp.tests/TestResults/test-results.xml' 
            } else {
                echo 'No test report files found.'
            }
        }
    }
   }
    
}
