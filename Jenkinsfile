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
    }

    post {
        success {
            echo 'Build, no test, and publish successful!'
        }
    }
}
