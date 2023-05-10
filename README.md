# Dacelo API

To run this you will have to do a few things! First of all
you will need to create a postgres container. This is no big
deal:

```
docker run --name dacelo-db -e POSTGRES_PASSWORD=8letters -e POSTGRES_USER=dacelo-db -e POSTGRES_DB=dacelo -p 5432:5432 -d postgres
```

After this you can run the API:

```
cd ./API/
dotnet run
```

While the API is running you can run the Tester in ./Tester/ to
test different API features. It currently does not work, however.