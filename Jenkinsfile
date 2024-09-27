pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:8.0'
            args '-v /var/run/docker.sock:/var/run/docker.sock'
        }        
    }
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
                        sh 'dotnet --version'  // Vérifier la version de .NET
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
