db.auth('root', 'cjEU5GaFKH3i')

db.createCollection('log')

db.createUser({
  user: 'user',
  pwd: 'r5A8CAweFz2h',
  roles: [
    {
      role: 'readWrite',
      db: 'blacklist',
    },
  ],
});
