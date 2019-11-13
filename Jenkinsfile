pipeline{
    agent { label 'master' }
    parameters{
        string(
            name: "GIT_SSH_PATH",
            defaultValue: "git@github.com:tavisca-dgupta/Capi.AccessKey.git",
            description: "GIT HTTPS PATH"
        )
        string(
            name: "SOLUTION_PATH",
            defaultValue: "Tavisca.CAPI.AccessKey.sln",
            description: "SOLUTION_PATH"
        )
        string(
            name: "DOTNETCORE_VERSION",
            defaultValue: "2.2",
            description: "Version"
        )
        string(
            name: "TEST_SOLUTION_PATH",
            defaultValue: "Tavisca.CAPI.AccessKey.UnitTest/Tavisca.CAPI.AccessKey.UnitTest.csproj",
            description: "TEST SOLUTION PATH"
        )
        string(
            name: "PROJECT_PATH",
            defaultValue: "Tavisca.CAPI.AccessKey.Web/Tavisca.CAPI.AccessKey.Web.csproj",
            description: "PROJECT PATH"
        )
         string(
            name: "DOCKERFILE",
            defaultValue: "mcr.microsoft.com/dotnet/core/aspnet",
        )
         string(
            name: "DOCKERHUB_USER_NAME",
            description: "Enter Docker hub Username"
        )
        string(
            name: "DOCKERHUB_PASSWORD",
            description:  "Enter Docker hub Password"
        )
        string(
            name: "DOCKERHUB_REPO",
            defaultValue: "capiaccesskey"
        )
        string(
            name: "SOLUTION_DLL_FILE",
            defaultValue: "capiaccesskey.dll",
        )
        choice(
            name: "RELEASE_ENVIRONMENT",
            choices: ["Build","Deploy"],
            description: "Choose the operation"
        )
    }
    stages{
        stage('Build'){
            when{
                expression{params.RELEASE_ENVIRONMENT == "Build" || params.RELEASE_ENVIRONMENT == "Deploy" }
            }
            steps{
                sh '''
                    echo '====================Restore Project Start ================'
                    git submodule sync 
                    git submodule update --init --recursive
                    dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json
                    echo '=====================Restore Project Completed============'
                    echo '====================Build Project Start ================'
                    dotnet build ${PPOJECT_PATH} 
                    echo '=====================Build Project Completed============'
                    echo '====================Test Project Start ================'
                    dotnet test ${TEST_SOLUTION_PATH}
                    echo '=====================Test Project Completed============'
                    echo '====================Publish Start ================'
                    dotnet publish ${PROJECT_PATH}
                    echo '=====================Publish Completed============'
                '''
            }
        }
        stage('Deploy'){
            when{
                expression{params.RELEASE_ENVIRONMENT == "Deploy"}
            }
            steps{
                
                sh "docker build publish/ --tag=${DOCKERHUB_REPO}:${BUILD_NUMBER}"    
                sh "docker tag ${DOCKERHUB_REPO}:${BUILD_NUMBER} ${DOCKER_USER_NAME}/${DOCKERHUB_REPO}:${BUILD_NUMBER}"
                sh "docker login -u ${DOCKER_USER_NAME} -p ${DOCKER_PASSWORD}" 
                sh "docker push ${DOCKER_USER_NAME}/${DOCKERHUB_REPO}:${BUILD_NUMBER}"
        }
    }
}
    post{
        always{
            deleteDir()
       }
    }
}
