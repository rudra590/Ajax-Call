function SvarRegistrion()
{
  

    Gen = "";
    if (rbMale.checked==true) {
        Gen = rbMale.value;
    }
    else if (rbFemale.checked==true) {
        Gen = rbFemale.value;
    }
    var TrnsferObj = {
        Name: txtName.value,
        Email:txtEmail.value,
        Gender:Gen
    };
    $.ajax({
        method : "POST",
        url : "/RegistrionTblService.asmx/Insert",
        contentType : "application/json; charset=UTF-8",
        dataType: "json",

        data : JSON.stringify(TrnsferObj),
        success : function(resopnce){
            console.log(resopnce);
            alert("Success Full Insert");
            txtName.value ="";
            txtEmail.value="";
            rbMale.checked=false;
            rbFemale.checked=false;
        },
        error : function(err){
            console.log(err);
            alert("Error occurred, check console");
        },
         complete: function()
         {
          FillGrid();
         }
   

      
    });
}
function FillGrid()
{
  
    $.ajax({
        url : "RegistrionTblService.asmx/list",
        dataType: "json",
        contentType : "application/json; charset=UTF-8",
        method : "POST",

        success : function(resopnce){
            var res = JSON.parse(resopnce.d);
            $("#TblData").empty();
            for (const item of res) {
              var row = `<tr>
                                      <td>${item.RegID}</td>
                                   <td>${item.Name}</td>
                                 <td>${item.Email}</td>
                            <td>${item.Gender}</td>
                               <td>${item.RegDate}</td>
                               <td>${item.RegDate}</td>
                               <td><button type="button" onclick=" EditBtn(${item.RegID})">Edit</button></td>
                               <td><button type="button" onclick=" DeleteBtn(${item.RegID})">Delete</button></td>

                               
                         </tr>`
$("#TblData").append(row);
// console.log(item);
}

},
error : function(err){
    console.log(err);
    alert("Error occurred1, check console");
},
});
}

function EditBtn(id)
{
  
   var TrnsferObj = {
      RegID:id
   }

   $.ajax({
    method :"POST",
    url :"/RegistrionTblService.asmx/Edit",
    contentType : "application/json; charset=UTF-8",
    dataType:"json",
    data : JSON.stringify(TrnsferObj),
    success : function (resopnce)
    {
     var res =JSON.parse(resopnce.d)[0];
               txtName.value =res.Name;
            txtEmail.value=res.Email;
           if (res.Gender == "Male") {
             rbMale.checked=true
           }
           else if (res.Gender == "FeMale") {
              rbFemale.checked = true
           }
           btn1.innerHTML = "Update";
           HidId.value = res.RegID;
      console.log(res)
    },
    error : function (err)
    {
       console.log(err),
            alert("Error occurred, check console");

    },

   });
}
function UpdateBtn ()
{
    debugger;
     Gen = "";
    if (rbMale.checked==true) {
        Gen = rbMale.value;
    }
    else if (rbFemale.checked==true) {
        Gen = rbFemale.value;
    }
    var TrnsferObj = {
        RegID :HidId.value,
        Name: txtName.value,
        Email:txtEmail.value,
        Gender:Gen
    };
    $.ajax({
    method : "POST",
    url : "/RegistrionTblService.asmx/Update",
    contentType :"application/json; charset=UTF-8",
    dataType : "json",
           data : JSON.stringify(TrnsferObj),
    success :function (resopnce) {
       console.log(resopnce);
            alert("Success FullUpdate ");
            txtName.value ="";
            txtEmail.value="";
            HidId.value ="0";
            rbMale.checked=false;
            rbFemale.checked=false;
            btn1.innerHTML = "Save";
    },
    err: function(err)
    {
        console.log(err)
    },
    complete: function()
         {
          FillGrid();
         }
   

    });
  

}
function DeleteBtn(id)
{
  if (confirm('Are You Sure Want To Delete Data') == true) {

    
  
   var TrnsferObj = {
      RegID:id
   }

   $.ajax({
    method :"POST",
    url :"/RegistrionTblService.asmx/Delete",
    contentType : "application/json; charset=UTF-8",
    dataType:"json",
    data : JSON.stringify(TrnsferObj),
    success : function (resopnce)
    {
     var res =resopnce.d;
      alert(res);
      console.log(res)
    },
    error : function (err)
    {
       console.log(err),
            alert("Error occurred, check console");

    },
    complete:function()
{
    FillGrid();
}

   });
}
}