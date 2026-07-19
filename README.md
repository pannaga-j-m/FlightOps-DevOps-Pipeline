# ✈️ Flight Management System - DevOps Deployment

## Project Overview

This project demonstrates the complete DevOps lifecycle for a Flight Management System using Jenkins, Docker, Docker Hub, and Kubernetes.

## Tech Stack

- Git & GitHub
- Jenkins
- Docker
- Docker Hub
- Kubernetes (Docker Desktop)
- Python (Frontend)
- ASP.NET (.NET) Backend

---

# Project Architecture

```
GitHub
   │
   ▼
Jenkins Pipeline
   │
   ▼
Docker Build
   │
   ▼
Docker Hub
   │
   ▼
Kubernetes (Docker Desktop)
```

---

# Step 1: Clone Repository

```bash
git clone https://github.com/moriya-buchris/Flight-Management-System.git
```

---

# Step 2: Dockerize the Application

Created Dockerfiles for:

- Frontend
- Backend

### Backend Image

```bash
docker build -t flight-backend ./Backend
```

### Frontend Image

```bash
docker build -t flight-frontend ./Frontend
```

---

# Step 3: Jenkins CI Pipeline

Configured Jenkins pipeline with stages:

- Checkout Source Code
- Build Backend Image
- Build Frontend Image
- Docker Login
- Push Images to Docker Hub
- Deploy Containers

---

# Step 4: Push Images to Docker Hub

Docker Hub Repository

```
pannagajm2004/flight-backend
```

```
pannagajm2004/flight-frontend
```

Commands:

```bash
docker login

docker tag flight-backend pannagajm2004/flight-backend:latest
docker tag flight-frontend pannagajm2004/flight-frontend:latest

docker push pannagajm2004/flight-backend:latest
docker push pannagajm2004/flight-frontend:latest
```

---

# Step 5: Kubernetes Setup

Enabled Kubernetes in Docker Desktop.

Verified cluster:

```bash
kubectl config current-context
```

Output

```
docker-desktop
```

Verified node

```bash
kubectl get nodes
```

Output

```
desktop-control-plane Ready
```

---

# Step 6: Kubernetes Deployment

Created Kubernetes manifests:

```
k8s/
│
├── backend-deployment.yaml
├── backend-service.yaml
├── frontend-deployment.yaml
├── frontend-service.yaml
```

Applied manifests

```bash
kubectl apply -f k8s/
```

---

# Step 7: Verify Deployment

Check Pods

```bash
kubectl get pods
```

Check Services

```bash
kubectl get svc
```

---

# Backend Status

Backend deployment successfully running.

```
2/2 Pods Running
```

Backend service created successfully.

---

# Frontend Issue

Backend deployed successfully.

Frontend image pulls successfully but application crashes.

Initial Error

```
ImportError: libGL.so.1: cannot open shared object file
```

Updated Dockerfile by installing

```
libgl1
```

Current Issue

```
ImagePullBackOff
```

Reason

```
unexpected EOF while pulling image
```

Currently troubleshooting Docker image pull issue.

---

# Useful Kubernetes Commands

Check Pods

```bash
kubectl get pods
```

Describe Pod

```bash
kubectl describe pod <pod-name>
```

Check Logs

```bash
kubectl logs <pod-name>
```

Restart Deployment

```bash
kubectl rollout restart deployment flight-frontend
```

Delete Pods

```bash
kubectl delete pods -l app=flight-frontend
```

---

# Current Progress

✅ GitHub Repository

✅ Dockerized Application

✅ Jenkins CI Pipeline

✅ Docker Hub Integration

✅ Kubernetes Cluster Created

✅ Backend Successfully Running

✅ Backend Service Running

✅ Frontend Deployment Created

🔄 Frontend Deployment Troubleshooting (Image Pull / PySide6 GUI dependency)

---

# Future Enhancements

- Fix Frontend Deployment
- Expose Frontend using NodePort/LoadBalancer
- Add Ingress Controller
- Configure Prometheus
- Configure Grafana
- Implement CI/CD Deployment to Kubernetes
- Deploy on AWS EKS
- Add Monitoring and Logging

---

# Author

**Pannaga J M**

Cloud & DevOps Engineer

GitHub: https://github.com/pannaga-j-m
