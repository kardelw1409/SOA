module.exports = (app) => {
    //require('module-alias/register');
    const profiles = require('./profile_controller');//

    // Create a new Profile
    app.post('/Profile', profiles.create);

    // Retrieve all Profiles
    app.get('/Profile', profiles.findAll);

    // Retrieve a single Profile with profileId
    app.get('/Profile/:profilesId', profiles.findOne);

    // Update a Profile with profileId
    app.put('/Profile/:profilesId', profiles.update);

    // Delete a Profile with profileId
    app.delete('/Profile/:profilesId', profiles.delete);
}