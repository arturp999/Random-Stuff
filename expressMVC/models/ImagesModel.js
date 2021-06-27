const User = require("./UserModel");

module.exports = (sequelize, DataTypes) => {
  Images = sequelize.define("image", {
    id: {
      allowNull: false,
      autoIncrement: true,
      primaryKey: true,
      type: DataTypes.INTEGER,
    },
    img_original_name: {
      type: DataTypes.STRING,
    },
    img_location: {
      type: DataTypes.STRING,
    },
    img_filename: {
      type: DataTypes.STRING,
    },
    user_img_id: {
      type: DataTypes.INTEGER,
      allowNull: false,
      onDelete: "CASCADE",
      onUpdate: "CASCADE",
      references: {
        model: "users",
        key: "id",
      },
    },
  });
  return Images;
};
