<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-5">

                    <div class="card shadow">

                        <!-- Header -->
                        <div class="card-header bg-primary text-white text-center">
                            <h4>Registration</h4>
                        </div>

                        <!-- Body -->
                        <div class="card-body">

                            <!-- Name -->
                            <div class="mb-3">
                                <label class="form-label">Name</label>
                                <input type="text" id="txtName" runat="server"
                                    class="form-control" placeholder="Enter Name" />
                            </div>

                            <!-- Email -->
                            <div class="mb-3">
                                <label class="form-label">Email</label>
                                <input type="email" id="txtEmail" runat="server"
                                    class="form-control" placeholder="Enter Email" />
                            </div>

                            <!-- Gender -->
                            <div class="mb-3">
                                <label class="form-label d-block">Gender</label>

                                <input type="radio" id="rbMale" runat="server" name="gender" />
                                <label for="rbMale">Male</label>

                                &nbsp;&nbsp;

                            <input type="radio" id="rbFemale" runat="server" name="gender" />
                                <label for="rbFemale">Female</label>
                            </div>

                            <!-- Save Button -->
                            <div class="d-grid">
                                   <input type="hidden" name="HidId" id="HidId" value="0"/>
                                <button type="button" class="btn btn-success"
                                    onclick="BtnClick()" id="btn1" name="btn1">
                                    Click Here
                                </button>

                            </div>

                        </div>
                    </div>

                </div>
            </div>
            <div class="card my-5">
                <div class="card-header">
                    <h4>Registrion</h4>
                </div>
                <div class="card-body table-responsive">
                    <table class="table table-borderd table-hover text-center">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Name</th>
                                <th>Email</th>
                                <th>Gender</th>
                                <th>Date</th>
                                <th>Edit</th>


                            </tr>
                        </thead>
                        <tbody id="TblData">
                       
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

    </form>
    <script src="js/jquery-3.7.1.min.js"></script>

    <script src="AjaxCall/RegistrionTbl.js"></script>
    <script>
        FillGrid();
        function BtnClick() {
            if (btn1.innerHTML == "Click Here") {
                      SvarRegistrion();
            }
            else
            {
                UpdateBtn();
            }
      
        }
    </script>
</body>
</html>
