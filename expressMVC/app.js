var createError = require("http-errors");
var express = require("express");
var path = require("path");
var cookieParser = require("cookie-parser");
var cors = require("cors");
var logger = require("morgan");


//flash messages//
const flash = require("connect-flash");
const session = require("express-session");

var app = express();


//database stuff
var db = require("./models");
app.listen(3001, function () {
  db.sequelize.sync(); //its going to create all the tables from the models in the app start
});


// view engine setup
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "ejs");


app.use('/users/uploads/', express.static('./uploads')); //need to be here or doesnt load the images, first is the route, then its the folder

//flash messages//
app.use(session({
  secret:'Who would know naught of art must learn, act, and then take his ease',
  cookie:{maxAge:6000},
  resave:false,
  saveUninitialized:false
}))
app.use(flash());

////ROUTES NEED TO BE BELLOW FLASH
var indexRouter = require("./routes/index");
var usersRouter = require("./routes/users");


//so we can read what we get from the body/Gets user input
const bodyParser = require("body-parser");
app.use(bodyParser.urlencoded({ extended: true }));
app.use(logger("dev"));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(cors());
app.use(express.static(path.join(__dirname, "public")));

app.use(express.static(__dirname + "/node_modules/bootstrap/dist"));

app.use("/", indexRouter);
app.use("/users", usersRouter);

// catch 404 and forward to error handler
app.use(function (req, res, next) {
  next(createError(404));
});

// error handler
app.use(function (err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get("env") === "development" ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render("error");
});

module.exports = app;
