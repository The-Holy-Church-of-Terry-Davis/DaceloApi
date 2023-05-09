# Dacelo API

To run this you will have to do a few things! First of all
you will need to create a postgres container. This is no big
deal:

```
docker run --name dacelo-db -e POSTGRES_PASSWORD=8letters -e POSTGRES_USER=dacelo-db -e POSTGRES_DB=dacelo -d postgres
```
