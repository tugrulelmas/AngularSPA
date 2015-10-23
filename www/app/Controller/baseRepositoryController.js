function BaseRepositoryCtrl($scope, context, translationService, restService) {
    BaseCtrl.call(this, $scope, context, translationService);
    list();

    $scope.list = function () {
        list();
    }

    $scope.setRecordStatus = function (value) {
        $scope.search.RecordStatus = value;
    };

    $scope.deleteConfirm = function (model) {
        $scope.setModel(model);
        $scope.showConfirmModal();
    }

    $scope.delete = function () {
        var deleteUrl = $scope.apiName + "/Delete?d='y'";
        restService.post(deleteUrl, $scope.selectedModel, function (result, isSuccess) {
            if (isSuccess) {
                noty({ text: $scope.ml("Global.DeletedMessage").format($scope.messageKey()), layout: 'top', type: 'success', timeout: 1500 });
                $scope.hideConfirmModal();
                if ($scope.selectedModel.RecordStatus) {
                    $scope.selectedModel.RecordStatus = false;
                } else {
                    $scope.modelList.splice($scope.modelList.indexOf($scope.selectedModel), 1);
                }
            }
        });
    }

    $scope.createDialog = function () {
        $scope.isNewRecord = true;
        $scope.setModel(null);
        $scope.showModal();
    }

    $scope.updateDialog = function (model) {
        $scope.isNewRecord = false;
        $scope.setModel(model);
        $scope.showModal();
    }

    $scope.createOrUpdate = function () {
        if ($scope.isNewRecord) {
            $scope.create();
        } else {
            $scope.update();
        }
    }

    $scope.messageKey = function () {
        return $scope.selectedModel.Name;
    }

    $scope.isModalValid = function () {
        return $scope.selectedModel && $scope.selectedModel.Code && $scope.selectedModel.Name && ($scope.selectedModel.RecordStatus === true || $scope.selectedModel.RecordStatus === false);
    }

    $scope.setModel = function (model) {
        $scope.selectedModel = model;
        if (model) {
            $scope.warningMessageOnDeleting = $scope.ml("Global.WarningMessageOnDeleting").format($scope.messageKey());
        }
    }

    $scope.create = function () {
        var createUrl = $scope.apiName + "/Add";
        restService.post(createUrl, $scope.selectedModel, function (result, isSuccess) {
            if (isSuccess) {
                noty({ text: $scope.ml("Global.AddedMessage").format($scope.messageKey()), layout: 'top', type: 'success', timeout: 1500 });
                $scope.selectedModel = result;
                $scope.hideModal();
                $scope.modelList.push($scope.selectedModel);
            }
        });
    }

    $scope.update = function () {
        var updateUrl = $scope.apiName + "/Update";
        restService.put(updateUrl, $scope.selectedModel, function (result, isSuccess) {
            if (isSuccess) {
                noty({ text: $scope.ml("Global.UpdatedMessage").format($scope.messageKey()), layout: 'top', type: 'success', timeout: 1500 });
                $scope.hideModal();
            }
        });
    }

    function list() {
        $scope.search = {};
        $scope.search.RecordStatus = true;
        restService.get($scope.apiName, function (result, isSuccess) {
            if (isSuccess) {
                $scope.modelList = result;
            }
        });
    }
}
