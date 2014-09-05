(function () {
    'use strict';
    angular.module("app")
        .controller('MainCtrl', function ($scope, $http) {
            $scope.convertText = function (text) {
                $http.post('/api/mutuallinker', { text: text }).success(function (dataWithText) {
                    $scope.text = dataWithText.text;
                });
            }

            $scope.text = "Odwoluje sie do[1]\n\n\n" +
                "[1]blabla";
        });
})();