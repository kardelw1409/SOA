﻿var ViewModel = function () {  
  
    var self = this;
    self.Course = ko.observable();
    self.Enrolled = ko.observable();
    self.GroupId = ko.observable();  
    self.Roomid = ko.observable();
    self.Id = ko.observable();
    
  
    self.studentList = ko.observableArray([]);  
  
    var StudentUri = '/api/Students/';  
  
      
  
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
        self.Course('');
        self.Enrolled('');
        self.GroupId('');
        self.Roomid('');
        self.Id(''); 
    }  
  
    //Add new Student  
    self.addNewStudent = function addNewStudent(newStudent) {  
  
        var StudObject = {
            Course: self.Course(),
            Enrolled: self.Enrolled(),
            GroupId: self.GroupId(),  
            Roomid: self.Roomid(),
            Id: self.Id()
        };  
        ajaxFunction(StudentUri, 'POST', StudObject).done(function () {  
  
            self.clearFields();  
            alert('Student Added Successfully !');  
            getStudentList()  
        });  
    }  
  
    //Get Student List  
    function getStudentList() {  
        $("div.loadingZone").show();  
        ajaxFunction(StudentUri, 'GET').done(function (data) {  
            $("div.loadingZone").hide();  
            self.studentList(data);  
        });  
  
    }  
  
    //Get Detail Student  
    self.detailStudent = function (selectedStudent) {  
        self.Course(selectedStudent.Course);
        self.Enrolled(selectedStudent.Enrolled);
        self.Roomid(selectedStudent.Roomid);  
        self.GroupId(selectedStudent.GroupId);
        self.Id(selectedStudent.Id);
  
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
  
    //Update Student  
    self.updateStudent = function () {  
  
        var StudObject = {
            Course: self.Course(),
            Enrolled: self.Enrolled(),
            Roomid: self.Roomid(),  
            GroupId: self.GroupId(),
            Id: self.Id()
        };  
  
        ajaxFunction(StudentUri + self.Id(), 'PUT', StudObject).done(function () {  
            alert('Student Updated Successfully !');  
            getStudentList();  
            self.cancel();  
        });  
    }  
  
    //Delete Student  
    self.deleteStudent = function (student) {  
  
        ajaxFunction(StudentUri + student.Id, 'DELETE').done(function () {  
  
            alert('Student Deleted Successfully');  
            getStudentList();  
        })  
  
    }  
  
    
    getStudentList();
  
};  
  
ko.applyBindings(new ViewModel());  