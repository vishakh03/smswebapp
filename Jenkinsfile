pipeline {
    agent any

    environment {
        // This is not needed unless you are setting a specific DOTNET_CLI_HOME
        // For most cases, the default will work.
        // Remove if unnecessary
        DOTNET_CLI_HOME = "${env.WORKSPACE}"
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
    }

    post {
        success {
            echo '✅ Build, test, and publish successful!'
        }
        failure {
            echo '❌ Something went wrong.'
        }
    }
}
