var ViewModel = function () {

    var self = this;
    self.IsDone = ko.observable();
    self.SubjectId = ko.observable();
    self.StudentId = ko.observable();
    self.Id = ko.observable();


    self.PerformanceList = ko.observableArray([]);

    var PerformanceUri = '/api/Performances/';



    function ajaxFunction(uri, method, data) {

        //self.errorMessage('error');  

        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null

        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error  ' + errorThrown);
        });
    }


    // Clear Fields  
    self.clearFields = function clearFields() {
        self.IsDone('');
        self.SubjectId('');
        self.StudentId('');
        self.Id('');
    }

    //Add new Performance  
    self.addNewPerformance = function addNewPerformance(newPerformance) {

        var PerfObject = {
            IsDone: self.IsDone(),
            SubjectId: self.SubjectId(),
            StudentId: self.StudentId(),
            Id: self.Id()
        };
        ajaxFunction(PerformanceUri, 'POST', PerfObject).done(function () {

            self.clearFields();
            alert('Performance Added Successfully !');
            getPerformanceList()
        });
    }

    //Get Performance List  
    function getPerformanceList() {
        $("div.loadingZone").show();
        ajaxFunction(PerformanceUri, 'GET').done(function (data) {
            $("div.loadingZone").hide();
            self.PerformanceList(data);
        });

    }

    //Get Detail Performance  
    self.detailPerformance = function (selectedPerformance) {
        self.IsDone(selectedPerformance.IsDone);
        self.SubjectId(selectedPerformance.SubjectId);
        self.StudentId(selectedPerformance.StudentId);
        self.Id(selectedPerformance.Id);

        $('#Save').hide();
        $('#Clear').hide();

        $('#Update').show();
        $('#Cancel').show();

    };

    self.cancel = function () {

        self.clearFields();

        $('#Save').show();
        $('#Clear').show();

        $('#Update').hide();
        $('#Cancel').hide();
    }

    //Update Performance  
    self.updatePerformance = function () {
        var PerfObject = {
            IsDone: self.IsDone(),
            SubjectId: self.SubjectId(),
            StudentId: self.StudentId(),
            Id: self.Id()
        };

        ajaxFunction(PerformanceUri, 'PUT', PerfObject).done(function () {
            alert('Performance Updated Successfully !');
            self.cancel();
            getPerformanceList();
        });
    }


    //Delete Performance  
    self.deletePerformance = function (Performance) {

        ajaxFunction(PerformanceUri + Performance.Id, 'DELETE').done(function () {

            alert('Performance Deleted Successfully');
            getPerformanceList();
        })

    }


    getPerformanceList();

};

ko.applyBindings(new ViewModel());