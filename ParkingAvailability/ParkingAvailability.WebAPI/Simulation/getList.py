# coding=utf-8

data = {
      "lat": [
        55.655487,
        55.68193945,
        55.58177015,
        55.6093765,
        55.67597305,
        55.730359400000005,
        55.63897675,
        55.75063535,
        55.74678675,
        55.6835672,
        55.733700600000006,
        55.63189905,
        55.6565488,
        55.6158065,
        55.78463789999999,
        55.69020045,
        55.632181,
        55.85554895,
        55.761213100000006,
        55.95092905,
        55.83480805,
        55.80184975,
        56.0489253,
        55.954790100000004,
        56.036131999999995,
        55.92391415,
        55.882803,
        55.8367165,
        55.14320545,
        55.587672700000006,
        55.45165575,
        55.63683505,
        55.64848955,
        55.53752785,
        55.26956345,
        54.77308455,
        55.65399865,
        55.607900300000004,
        54.777744999999996,
        55.26205875,
        55.871771499999994,
        55.457927000000005,
        55.34784165,
        55.47768320000001,
        55.33128645,
        55.05838765,
        55.276659499999994,
        55.19639605,
        55.471725199999995,
        54.94323035,
        55.4470245,
        55.51401385,
        55.298672700000004,
        55.38510955,
        55.124010899999995,
        54.8940503,
        55.74515965,
        55.408791799999996,
        55.40483125,
        55.56872025,
        55.2539735,
        55.46893910000001,
        54.9680683,
        55.06300285,
        55.66299975,
        55.45860825,
        55.76169025,
        54.98406415,
        56.3195826,
        55.7966108,
        55.933767599999996,
        56.451178399999996,
        55.9302471,
        56.536008200000005,
        55.88341465,
        56.18178635,
        56.08543625,
        56.27146895,
        56.163029099999996,
        56.146396200000005,
        56.39602965,
        56.05259345,
        56.52891025,
        56.01770905,
        56.64592439999999,
        56.48359285,
        56.45089399999999,
        57.20558525,
        57.46118845,
        57.46287325,
        57.18135935,
        57.271898,
        56.7056461,
        56.82668535,
        56.8112213,
        56.914681099999996,
        56.82459179999999,
        57.1083005
      ],
      "lon": [
        12.6017091757021,
        12.5234311321118,
        12.6391376954815,
        12.5942740849782,
        12.352005353638802,
        12.3652198552314,
        12.405229619358002,
        12.546095186083301,
        12.475054122700099,
        12.4128011280619,
        12.4294512663628,
        12.467258591357501,
        12.2433210246525,
        12.3372606527787,
        12.504609606425099,
        12.448045107651902,
        12.3711979917191,
        12.338868116565001,
        12.215054578633803,
        12.4418298844488,
        12.133967219942901,
        12.3741493506794,
        12.2212375848805,
        11.8976375948996,
        12.506334289793598,
        12.231350031075001,
        12.4751045277793,
        12.4851539405034,
        14.922572149451803,
        12.238334005629401,
        12.067159476141,
        11.8977170646069,
        12.081161571340699,
        12.1696167523719,
        12.0936612283664,
        11.696799695220001,
        11.579777966691198,
        11.2607725160433,
        11.268772106522698,
        11.7086104858358,
        11.6072366935535,
        11.814083004867198,
        11.3511637763748,
        11.553972566515998,
        12.343941761360199,
        11.9743697688812,
        10.065789598896401,
        10.4279959085546,
        10.628370489078598,
        10.7774666199918,
        9.93699440734142,
        10.2380365346038,
        10.6805007292906,
        10.3528549062516,
        10.5948494522485,
        10.323877864166802,
        8.991930288159981,
        8.74821207640545,
        8.42501693939674,
        9.66933721767076,
        9.25144726299781,
        9.46848870480258,
        9.9319793323754,
        8.8895097299476,
        8.50962324687059,
        9.03169966141134,
        9.353391936956381,
        9.352327083916132,
        9.9287910995187,
        9.780827967815599,
        9.77020353202944,
        10.6086888262547,
        10.1415876875134,
        10.0019590933949,
        10.611506919188301,
        9.608746257423869,
        9.85078298627467,
        10.6629495150149,
        10.093856472099,
        8.861111142392689,
        8.70948934753083,
        9.25856612235464,
        8.30298414961857,
        8.54765064643927,
        8.93273216015491,
        8.54873787864715,
        9.38277399672349,
        10.1908697228908,
        10.4541721370818,
        10.0755791676103,
        9.662500790842989,
        10.9927582209678,
        9.92006634612026,
        8.729318998998421,
        10.002517045260301,
        8.482800502370191,
        9.405666946345491,
        10.012425315537099
      ],
}


locations = [
    ["SPAR",320],
    ["Meny",190],
    ["7-Eleven",177],
    ["Netto",500],
    ["DøgnNetto",45],
    ["Kvickly",81],
    ["Aldi",244],
    ["Bilka",18],
    ["Dagli'Brugsen",375],
    ["SuperBrugsen",230],
    ["Fakta",420],
    ["Føtex",88],
    ["Irma",71],
    ["Lidl",98],
    ["LokalBrugsen",375],
    ["Let-Køb",100],
    ["Løvbjerg",16],
    ["REMA 1000",317],
]


import random
import datetime
import uuid
import requests
from tqdm import tqdm

MAX_PARKING_SPOTS = 45
MIN_PARKING_SPOTS = 10

lat = data['lat']
lon = data['lon']
coordinates = list(zip(lat, lon))
coord_len = len(coordinates)


class Sensor(object):
    def __init__(self, sen_id, owner, coordinates, owner_id):
        self.id = sen_id
        self.owner = owner
        self.owner_id = owner_id
        self.coordinates = coordinates
        self.occupied = False

    def __str__(self):
        return self.id + "," + self.owner + "," + self.owner_id + "," + str(self.coordinates) + "," + str(self.occupied)

    def update(self):
        self.occupied = not self.occupied
        return self.id + "," + self.owner + "," + self.owner_id + "," + str(self.coordinates) + "," + str(self.occupied) + '\n'

    def register(self):
        reg = {
            "Id": self.id,
            "Owner": self.owner,
            "Owner_id": self.owner_id,
            "Coordinates": str(self.coordinates),
            "Occupied": str(self.occupied)}
        return reg

parking_list = []
stores = []

for loc in tqdm(coordinates, desc='Loading coordinates'):
    while True:
        owner_spot = locations[random.randint(0, len(locations)-1)]

        if (float(owner_spot[1]) / 1000.0) > random.random():
            store_id = str(uuid.uuid4())
            stores.append({
                "id": store_id,
                "store": owner_spot[0],
                "coordinates": loc})
            parking_list.append([owner_spot[0], loc, random.randint(MIN_PARKING_SPOTS, MAX_PARKING_SPOTS), store_id])
            break

all_sensors = []
for spot in tqdm(parking_list, desc='Loading parking spots'):
    for num_sensors in range(random.randint(MIN_PARKING_SPOTS, MAX_PARKING_SPOTS)):
        sen_id = str(uuid.uuid4())
        all_sensors.append(Sensor(sen_id, spot[0], spot[1], spot[3]))

len_all_sensors = len(all_sensors) - 1

quiet_hour_begin = 22
POST_quiet_traffic = (30, 60)

rush_hour_begin = 8
POST_rush_traffic = (100, 400)

time = datetime.datetime.now()

POST_traffic = None

url = 'http://localhost:54509/'
parkingURL = url+'api/parkingLocation'
sensorURL = url+'api/sensor'
postURL = url+'api/sensorpost'

for store in tqdm(stores, desc='registering stores'):
	requests.post(url=parkingURL, json=store)

for sensor in tqdm(all_sensors, desc='registering sensors'):
    requests.post(sensorURL, json=sensor.register())


while True:
    if time.hour < quiet_hour_begin:
        POST_traffic = POST_quiet_traffic
    elif time.hour < rush_hour_begin:
        POST_traffic = POST_rush_traffic

    date_time = time.strftime("%d/%m/%Y,%H:%M:%S")

    requests_list = []

    for _ in range(random.randint(POST_traffic[0], POST_traffic[1])):
        sensor = all_sensors[random.randint(0, len_all_sensors)]            
        requests_list.append(date_time + ',' + sensor.update())
    
    random.shuffle(requests_list)
    
    for req in requests_list:
        requests.post(url=postURL, json=req[1])
    
    time = time + datetime.timedelta(seconds=60)