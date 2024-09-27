pipeline {
    agent any
    environment {
        DOTNET_CLI_HOME = "C:\\Program Files\\dotnet"
    }
    stages {
         stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                echo 'Building the project...'
             script {
                    if (isUnix()) {
                        // Pour Linux/MacOS
                        sh "dotnet restore"
                        sh "dotnet build --configuration Release"
                    } else {
                        // Pour Windows
                        bat "dotnet restore"
                        bat "dotnet build --configuration Release"
                    }
                }             
            }
        }
    }
}
