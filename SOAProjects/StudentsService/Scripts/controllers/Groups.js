var ViewModel = function () {

    var self = this;
    self.Name = ko.observable();
    self.Course = ko.observable();
    self.SpecialityId = ko.observable();
    self.Id = ko.observable();


    self.groupList = ko.observableArray([]);

    var GroupUri = '/api/Groups/';



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
        self.Name('');
        self.Course('');
        self.SpecialityId('');
        self.Id(''); 
    }

    //Add new Group  
    self.addNewGroup = function addNewGroup(newGroup) {

        var GrupObject = {
            Name: self.Name(),
            Course: self.Course(),
            SpecialityId: self.SpecialityId(),
            //Id: self.Id()
        };
        ajaxFunction(GroupUri, 'POST', GrupObject).done(function () {

            self.clearFields();
            alert('Group Added Successfully !');
            getGroupList()
        });
    }

    //Get Group List  
    function getGroupList() {
        $("div.loadingZone").show();
        ajaxFunction(GroupUri, 'GET').done(function (data) {
            $("div.loadingZone").hide();
            self.groupList(data);
        });

    }

    //Get Detail Group  
    self.detailGroup = function (selectedGroup) {
        self.Name(selectedGroup.Name);
        self.Course(selectedGroup.Course);
        self.SpecialityId(selectedGroup.SpecialityId);
        self.Id(selectedGroup.Id);

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

    //Update Group  
    self.updateGroup = function () {
        var GrupObject = {
            Name: self.Name(),
            Course: self.Course(),
            SpecialityId: self.SpecialityId(),
            Id: self.Id()
        };

        ajaxFunction(GroupUri, 'PUT', GrupObject).done(function () {
            alert('Group Updated Successfully !');
            self.cancel();
            getGroupList();
        });
    }


    //Delete Group  
    self.deleteGroup = function (group) {

        ajaxFunction(GroupUri + group.Id, 'DELETE').done(function () {

            alert('Group Deleted Successfully');
            getGroupList();
        })

    }


    getGroupList();

};

ko.applyBindings(new ViewModel());