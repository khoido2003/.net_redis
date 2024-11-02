# .NET API with Redis

## Running redis shell inside a container

bash
```
docker ps  // To see the current running container and get its id 

docker exec -it + "id container" + /bin/bash  // open shell inside a container

redis-cli  // Start redis

set platform:10010 Docker

get platform:10010 "Docker"
```

Listing Running Containers (docker ps):

The command docker ps lists all running containers on your system. In the output, you can see:
    Container ID: 2106bdf674ca
    Image: redis
    Ports: 0.0.0.0:6379->6379/tcp, which indicates that port 6379 of the container is mapped to 6379 on your host machine, allowing you to interact with Redis from outside the container.
    The container name is redis_api, which helps identify it.

Accessing the Redis Container (docker exec -it <container_id> /bin/bash):

    docker exec -it 2106bdf674ca /bin/bash allows you to open an interactive bash shell inside the running Redis container. Here, you enter the container’s command line as the root user, enabling you to execute commands within the container environment.

Starting the Redis CLI (redis-cli):

    Inside the container, you run redis-cli, which launches the Redis command-line interface. This allows you to interact with the Redis database through the command line, issuing commands to test or manipulate the data in the Redis instance.

Pinging Redis (ping):

    The ping command in Redis tests the connection. When you enter ping, Redis responds with PONG, indicating that the server is running and responsive.

Setting a Key-Value Pair (set platform:10010 Docker):

    The command set platform:10010 Docker stores a key-value pair in Redis.
        Key: platform:10010
        Value: Docker
    Redis returns OK, meaning that it successfully saved the data.

Retrieving a Value (get platform:10010):

    The command get platform:10010 retrieves the value associated with the key platform:10010.
    Redis responds with "Docker", confirming that the value was correctly stored and retrieved from the Redis database.


### Command Structure and Explanation

bash 
```
docker exec -it <container_id> <command>
```
-i: Runs the command in interactive mode, keeping STDIN open.
-t: Allocates a pseudo-TTY, which is needed for an interactive terminal (like bash).
<container_id>: The ID or name of the container you want to access.
<command>: The command you want to run inside the container (e.g., /bin/bash for a shell, or redis-cli).

### Example of Adding a Shell for Troubleshooting (Temporary Container)

If you want to temporarily troubleshoot an image that doesn’t allow a shell, you can start a new container based on the same image but with shell access enabled:

bash 
```
docker run -it --entrypoint /bin/sh <image_name>
```
This bypasses the original entry point and gives you direct shell access, which is useful for debugging or exploring the container environment.

<!-- /////////////////////////////// -->

## Create .NET project

bash 
```
dotnet new webapi -n NetRedis
```

## Isue with the HTTPS
bash
```
dotnet dev-certs https --trust
```

## Add package
bash
```
dotnet add package + name
```
Find more packages at https://www.nuget.org

## Run the project
bash
```
dotnet run
```

## Set secret userId
bash
```
dotnet user-secrets init

dotnet user-secrets set "UserId" "sa"

dotnet user-secrets set "Password" "PASSWORD"

dotnet user-secrets remove "Password"

dotnet user-secrets remove "UserId"

```

## Install dotnet-ef
bash 
```
dotnet tool install --global dotnet-ef
```

## Create migration
bash 
``` 
dotnet ef migrations add + migrationName
```

## Remove migration
bash
```
dotnet ef migrations remove
```

## Update DB
bash 
```
dotnet ef database update
```

## Clear nuget local
bash 
```
dotnet nuget locals all --clear
```
