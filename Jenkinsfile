pipeline {
    agent any

    stages {

        stage('Build Frontend') {
            steps {
                sh 'docker build -t flight-frontend ./Frontend'
            }
        }

        stage('Build Backend') {
            steps {
                sh 'docker build -t flight-backend ./Backend'
            }
        }

        stage('Stop Old Containers') {
            steps {
                sh 'docker rm -f flight-frontend || true'
                sh 'docker rm -f flight-backend || true'
            }
        }

        stage('Run Backend') {
            steps {
                sh 'docker run -d --name flight-backend -p 3000:3000 flight-backend'
            }
        }

        stage('Run Frontend') {
            steps {
                sh 'docker run -d --name flight-frontend -p 5000:5000 flight-frontend'
            }
        }

        stage('Verify') {
            steps {
                sh 'docker ps'
            }
        }
        stage('Docker Login') {
     steps {
        withCredentials([usernamePassword(
            credentialsId: 'dockerhub',
            usernameVariable: 'DOCKER_USER',
            passwordVariable: 'DOCKER_PASS'
        )]) {
            sh '''
            echo "$DOCKER_PASS" | docker login -u "$DOCKER_USER" --password-stdin
            '''
        }
    }
}

stage('Push Images') {
    steps {
        sh '''
        docker tag flight-frontend YOUR_USERNAME/flight-frontend:latest
        docker tag flight-backend YOUR_USERNAME/flight-backend:latest

        docker push YOUR_USERNAME/flight-frontend:latest
        docker push YOUR_USERNAME/flight-backend:latest
        '''
    }
}
    }
}
