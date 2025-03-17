pipeline {
    agent any
    
    environment {
        UNITY_PATH = '/path/to/Unity/Editor/Unity' // Update with your Unity path on the VM
        GITHUB_TOKEN = credentials('github-token')
        PROJECT_PATH = '${WORKSPACE}'
        BUILD_VERSION = '1.0.${BUILD_NUMBER}'
    }
    
    stages {
        stage('Prepare') {
            steps {
                checkout scm
            }
        }
        
        stage('Build Windows') {
            steps {
                sh "${UNITY_PATH} -batchmode -quit -projectPath ${PROJECT_PATH} -executeMethod BuildScript.BuildWindows -logFile unity_win_build.log"
                sh "zip -r windows-build-${BUILD_VERSION}.zip Builds/Windows/"
            }
        }
        
        stage('Build macOS') {
            steps {
                sh "${UNITY_PATH} -batchmode -quit -projectPath ${PROJECT_PATH} -executeMethod BuildScript.BuildMacOS -logFile unity_mac_build.log"
                sh "tar -czvf macos-build-${BUILD_VERSION}.tar.gz Builds/macOS/"
            }
        }
        
        stage('Release to GitHub') {
            steps {
                sh '''
                    REPO_OWNER="your-github-username"
                    REPO_NAME="your-repo-name"
                    
                    # Create GitHub release
                    API_JSON=$(printf '{"tag_name": "v%s","name": "Release v%s","body": "Automated build for version %s","draft": false,"prerelease": false}' $BUILD_VERSION $BUILD_VERSION $BUILD_VERSION)
                    
                    RESPONSE=$(curl -H "Authorization: token ${GITHUB_TOKEN}" \
                         --data "$API_JSON" \
                         "https://api.github.com/repos/${REPO_OWNER}/${REPO_NAME}/releases")
                    
                    # Extract release ID
                    RELEASE_ID=$(echo $RESPONSE | grep -oP '"id": \\K[0-9]+' | head -1)
                    
                    # Upload Windows build
                    curl -H "Authorization: token ${GITHUB_TOKEN}" \
                         -H "Content-Type: application/zip" \
                         --data-binary @windows-build-${BUILD_VERSION}.zip \
                         "https://uploads.github.com/repos/${REPO_OWNER}/${REPO_NAME}/releases/${RELEASE_ID}/assets?name=windows-build-${BUILD_VERSION}.zip"
                    
                    # Upload macOS build
                    curl -H "Authorization: token ${GITHUB_TOKEN}" \
                         -H "Content-Type: application/gzip" \
                         --data-binary @macos-build-${BUILD_VERSION}.tar.gz \
                         "https://uploads.github.com/repos/${REPO_OWNER}/${REPO_NAME}/releases/${RELEASE_ID}/assets?name=macos-build-${BUILD_VERSION}.tar.gz"
                '''
            }
        }
    }
    
    post {
        always {
            archiveArtifacts artifacts: 'unity_*.log', allowEmptyArchive: true
            cleanWs()
        }
    }
}