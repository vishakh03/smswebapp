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
                bat 'dotnet test --configuration Release --no-build --no-restore'
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
        success {
            echo '✅ Build, test, publish successful!'
        }
        failure {
            echo '❌ Something went wrong.'
        }
    }
}
