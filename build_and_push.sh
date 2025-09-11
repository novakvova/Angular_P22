#!/bin/bash
set -e  # зупиняє скрипт при помилці

cd my-angular
docker build -t angular-p22-client .
docker login
docker tag angular-p22-client:latest novakvova/angular-p22-client:latest
docker push novakvova/angular-p22-client:latest
echo "Done ---client---!"

cd ..

cd WebATBApi
docker build -t angular-p22-api .
docker tag angular-p22-api:latest novakvova/angular-p22-api:latest
docker push novakvova/angular-p22-api:latest
echo "Done ---api---!"

read -p "Press any key to exit..."
