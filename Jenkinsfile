pipeline {
    agent any

    environment {
        APP_NAME = "flight-management-system"
    }

    stages {

        stage('Checkout Source') {
            steps {
                echo "Cloning GitHub Repository..."
                checkout scm
            }
        }

        stage('Verify Docker') {
            steps {
                sh 'docker --version'
                sh 'docker compose version'
            }
        }

        stage('Build Docker Images') {
            steps {
                echo "Building Docker Images..."
                sh 'docker compose build'
            }
        }

        stage('Stop Existing Containers') {
            steps {
                echo "Stopping Existing Containers..."
                sh 'docker compose down || true'
            }
        }

        stage('Deploy Application') {
            steps {
                echo "Starting Containers..."
                sh 'docker compose up -d'
            }
        }

        stage('Verify Deployment') {
            steps {
                sh 'docker ps'
            }
        }
    }

    post {

        success {
            echo 'Application deployed successfully.'
        }

        failure {
            echo 'Pipeline failed.'
        }

        always {
            echo 'Pipeline execution completed.'
        }
    }
}
