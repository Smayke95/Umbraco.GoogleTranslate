const googleTranslateEndpoint = '/umbraco/backoffice/api/googletranslate/translate';

angular.module('umbraco.services').factory('googleTranslateService', [

    '$http',

    function ($http) {

        return {
            translate: function (translateRequest, cb, cbError) {
                $http({
                    method: 'POST',
                    url: googleTranslateEndpoint,
                    data: translateRequest,
                    headers: { 'Content-Type': 'application/json' }
                }).then(function (response) {
                    if (cb) {
                        cb(response.data);
                    }
                }, function (reason) {
                    if (cbError) {
                        cbError(reason.data);
                    }
                });
            }
        };
    }
]);