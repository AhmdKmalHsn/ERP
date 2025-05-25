function readSQL(sql) {
  var data = [];
  $.ajax({
    url: "/CRUD/Read",
    async: false,
    data: { sql: sql },
    success: function (res) {
        //console.log(res)
      data = res//JSON.parse(res);
    },
  });
  return data;
}
function readAjax(url,data) 
{
    var result = [];
    try
    {
        $.ajax({
            url: url,
            async: false,
            data: data,
            success: function (res) {
                //console.log(res)
                result = res//JSON.parse(res);
            },
        });
    }
    catch(ex)
    {
        console.log(ex);
    }
    return result;
}
function selectList(name,id,text,table)
{
    let data = readSQL(`select ${id},${id}+' '+${text} from ${table}`);
    let options = ``;
    for (var i = 0; i < data.length; i++) {
        options += `<option value=${data[i][id]}>${data[i][text]}</option>`
    }
    return `<select name="${name}">${options}</select>`;
}
/*function readSQL(sql) {
  var data = "";
  $.ajax({
    url: "/crud/getbysql",
    //async: false,
    data: { sql: sql },
    success: function (res) {
      //data = JSON.parse(res);
	  
	  return res;
    },
	
  }); 
}*/
function excuteSQL(sql) {
  var data = "";
  $.ajax({
    url: "/CRUD/Excute",
    async: false,
    data: { sql: sql },
    success: function (res) {
      data = JSON.parse(res);
    },
  });
  return data;
}
function EmpGet(user) {
  var cook = [];
  var sql1 =
    " select FileNumber from employees " +
    " where (" +
    "       ((select Employees from users2 where id= " +
    user +
    ")=1 and FileNumber in(select EmpId from EmpAssign where AssignId= " +
    user +
    "))or" +
    "	   ((select Employees from users2 where id= " +
    user +
    ")=-1 and FileNumber not in(select EmpId from EmpAssign where AssignId= " +
    user +
    "))" +
    "	  )or" +
    "	  (" +
    "	  ((select Departments from users2 where id= " +
    user +
    ")=1 and DepartementId in(select DeptId from DeptAssign where AssignId= " +
    user +
    "))or" +
    "	  ((select Departments from users2 where id= " +
    user +
    ")=-1 and DepartementId not in(select DeptId from DeptAssign where AssignId= " +
    user +
    "))" +
    "	  )or" +
    "	  (" +
    "	  ((select [All] from users2 where id= " +
    user +
    ")=0 and DepartementId in(0))or " +
    "	  ((select [All] from users2 where id= " +
    user +
    ")=1 and DepartementId not in(0))" +
    "	  )" +
    " order by cast(FileNumber as int)";
  var data = readSQL(sql1);
  for (var i = 0; i < data.length; i++) {
    cook.push(Object.values(data[i])[0]);
  }
  return cook;
}
