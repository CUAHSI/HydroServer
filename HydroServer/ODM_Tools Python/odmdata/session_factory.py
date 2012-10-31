from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
import os

# open the config file to get the connection string
fn = os.path.join(os.path.dirname(__file__), 'connection.cfg')
f = open(fn)
cnxn_string = f.read()

engine = create_engine(cnxn_string, echo=True)

# Create session maker
Session = sessionmaker(bind=engine)

def get_session():
	return Session()