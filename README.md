## Minimal Web Api 

# Description
A minimal web api with DDD and CQRS architecture. Apis job is to get finaicial data from various providers and (if possible) place orders to various financial brokers.

docker build -t financial-minimal-api  -f src/Financials.Minimal.WebApi/Dockerfile .
docker run -it --rm -p 5000:80 financial-minimal-api
http://localhost:5000/swagger/index.html