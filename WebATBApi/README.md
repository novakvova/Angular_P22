# pd322-asp

Create docker hub repository - publish
```
docker build -t angular-p22 . 
docker ps -a 
docker images

docker run -d --restart=always --name angular-p22-container -p 4098:8080 angular-p22

docker stop angular-p22-container
docker rm angular-p22-container

docker login
docker tag angular-p22:latest novakvova/angular-p22-api:0.1
docker push novakvova/angular-p22-api:0.1

docker pull novakvova/angular-p22-api:0.1
docker ps -a
docker run -d --restart=always --name angular-p22-container -p 4098:8080 novakvova/angular-p22-api:0.1
```