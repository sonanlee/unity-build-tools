def defaultDeploy = "Win64"
def allJob = currentBuild.fullDisplayName.tokenize('/') as String[];
MAIN_PROJECT_NAME = allJob.first();
def allTokens = MAIN_PROJECT_NAME.tokenize('-') as String[];
PLATFORM = allTokens.last();

pipeline {
  agent any
  environment {
      MY_PROJECT_NAME = "${JOB_NAME}"
  }
  stages {
    stage('error') {
      steps {
        echo "0 : ${JOB_NAME}"
        echo "A : ${JOB_BASE_NAME}"
        echo "B : ${BRANCH_NAME}"
        echo "C : ${currentBuild.projectName}"
        echo "C : ${currentBuild.fullProjectName}"
        echo "D : ${currentBuild.displayName}"
        echo "F : ${currentBuild.fullDisplayName}"
        echo "H : ${MAIN_PROJECT_NAME}"
        echo "I : ${PLATFORM}"
        echo "I : ${currentBuild.changeSets.first().getKind()}"
        echo "I : ${currentBuild.changeSets.last().getKind()}"
        echo "I : ${GIT_COMMIT}"
      }
    }
    stage ('if'){
      steps {
        script {
          if (MY_PROJECT_NAME == JOB_NAME)
          {
            echo("hello")
          }
          else
          {
            echo("bye")
          }
        }
      }
    }

  }
}