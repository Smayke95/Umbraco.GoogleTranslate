angular.module('umbraco').controller('googleTranslateEditorController', [

    '$scope',
    'notificationsService',
    'googleTranslateService',

    function ($scope, notificationsService, googleTranslateService) {

        $scope.loading = false;

        let targetLanguage = sessionStorage.getItem('GoogleTranslate.Language');
        if (!targetLanguage)
            targetLanguage = 'en';

        $scope.translateRequest = {
            text: $scope.model.umbracoProperty.property.value,
            sourceLanguage: '',
            targetLanguage: targetLanguage
        };

        $scope.translateResponse = { text: '' };

        $scope.translate = function () {
            $scope.loading = true;

            googleTranslateService.translate(
                $scope.translateRequest,
                function (response) {
                    $scope.translateResponse.text = response;
                    sessionStorage.setItem('GoogleTranslate.Language', $scope.translateRequest.targetLanguage)
                    $scope.loading = false;
                },
                function (error) {
                    console.log(error);
                    notificationsService.error('Error', error.ExceptionMessage);
                });
        }

        $scope.submit = function () {
            $scope.model.umbracoProperty.property.value = $scope.translateResponse.text;
            notificationsService.success('Success', $scope.model.umbracoProperty.property.label + ' updated');
            $scope.model.close();
        }
    }
]);