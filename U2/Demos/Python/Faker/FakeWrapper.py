from faker import Faker
import json

fake = Faker('en_US')

def get_one_fake():
    return(fake.name() + ", " + fake.address().replace('\n', ','))

def get_many_fake(count):
    fakes = []
    for i in range(0, count):
        fakes.append(fake.name() + ", " + fake.address().replace('\n', ','))
    json_fakes = json.dumps(fakes)
    return json_fakes
    
if __name__=='__main__':
    print(get_one_fake())
    print(get_many_fake(10))
