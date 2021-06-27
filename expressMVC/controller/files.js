//Multer stuff
var multer = require('multer');
// SET STORAGE
var storage = multer.diskStorage({
  destination: function (req, file, callback) {
    callback(null, "uploads");
  },
  filename: function (req, file, callback) {
    callback(null, Date.now()+ "_"+ file.originalname);
  },
});
var upload = multer({ storage: storage })


exports.upload = upload;