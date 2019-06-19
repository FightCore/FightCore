# Get the latest LTS of the ASP Net Core image.
FROM microsoft/aspnetcore-build:lts

# Copy all files into the working directory.
COPY . /app

# Set the working directory.
WORKDIR /app

# Run the restore and build commands
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

# Document which port should be exposed.
EXPOSE 80/tcp

# Run the commands to start the app.
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh