# TvCast.Api  
Main Api to Access show and cast data.  

## TvCast.ApiWorker  
Worker process to find show information in tvmaze and download the show data.

## TvCast.AzureFunctions  
BlobStorage trigger to process the show data.

# Running on Docker  
Requires `Docker Toolbox` or `Docker For Windows - Linux Containers` installed
On the parent solution folder perform the commands:  
`Attention: NodeJS installation is required for running gulp`.
```
yarn
gulp
```

## Testing With Postman  
Install Postman  
Import the files:
* `TvCast.postman_collection.json`
* `local.postman_environment.json`
* `docker.postman_environment.json`