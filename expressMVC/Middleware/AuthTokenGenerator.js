var jwt = require('jsonwebtoken');


const generateToken = (res, email, password) => {
  const token = jwt.sign({ email, password }, process.env.TOKEN_SECRET,{ expiresIn: '1800s' });
  return res.cookie('token', token, {
    expires: new Date(Date.now() + '1800s'),
    secure: false, // set to true if your using https
    httpOnly: true,
  });
};
module.exports = generateToken