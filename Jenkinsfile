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
                echo 'Building another one...'
            }
        }
    }
}
