# Shortlink

## Getting started

### Required

- [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
- [AWS CLI](https://aws.amazon.com/pt/cli/)
- [Docker](https://www.docker.com/)

### Clone project

Clone the project and run `dotnet restore`

### Installing the dependencies to run locally

We use the following services for data storage:

- PostgreSQL
- SQS

To provision these resources locally go to default folder and run `docker-compose up -d`

### Set up the aws-cli

> ❗ **Attention**: Install [aws-cli](https://docs.aws.amazon.com/cli/latest/userguide/getting-started-install.html)

Run:

```bash
aws configure --profile default
```

And set values:

```bash
AWS_ACCESS_KEY_ID="test"
AWS_SECRET_ACCESS_KEY="test"
AWS_REGION="us-east-1"
OUTPUT="json"
```
