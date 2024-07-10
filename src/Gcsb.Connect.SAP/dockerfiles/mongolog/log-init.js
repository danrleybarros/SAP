db.auth('root', 'vYqE0jREpF47')

db.createCollection('log')

db.createUser({
  user: 'user',
  pwd: 'HhW4*69C%pTb',
  roles: [
    {
      role: 'readWrite',
      db: 'logs',
    },
  ],
});
