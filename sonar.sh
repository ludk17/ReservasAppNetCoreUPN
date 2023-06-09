dotnet sonarscanner begin /k:"my-app" /d:sonar.login="squ_957502e783d65f59fd8471b59e1b5c1d9cca199f" /d:sonar.host.url="https://sonarqube.bit2bitamericas.com"
dotnet build
dotnet sonarscanner end /d:sonar.login="squ_957502e783d65f59fd8471b59e1b5c1d9cca199f"