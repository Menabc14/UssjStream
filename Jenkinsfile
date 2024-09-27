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
                // Restoring dependencies
                //bat "cd ${DOTNET_CLI_HOME} && dotnet restore"
                bat "dotnet restore"

                // Building the application
                bat "dotnet build --configuration Release"                
            }
        }
    }
}
