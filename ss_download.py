# 2023 (C) Crown Copyright, Met Office. All rights reserved.
#
# This file is part of Weather DataHub and is released under the
# BSD 3-Clause license.

# (c) Met Office 2023

import requests
import argparse
import time
import sys
import logging as log
import json

log.basicConfig(filename='ss_download.log', filemode='w', format='%(asctime)s - %(levelname)s - %(message)s')

base_url = "https://data.hub.api.metoffice.gov.uk/sitespecific/v0/point/"

def retrieve_forecast(baseUrl, timesteps, requestHeaders, latitude, longitude, excludeMetadata, includeLocation):
    
    url = baseUrl + timesteps 
    
    headers = {'accept': "application/json"}
    headers.update(requestHeaders)
    params = {
        'excludeParameterMetadata' : excludeMetadata,
        'includeLocationName' : includeLocation,
        'latitude' : latitude,
        'longitude' : longitude
        }

    success = False
    retries = 5

    while not success and retries >0:
        try:
            req = requests.get(url, headers=headers, params=params)
            success = True
        except Exception as e:
            log.warning("Exception occurred", exc_info=True)
            retries -= 1
            time.sleep(10)
            if retries == 0:
                log.error("Retries exceeded", exc_info=True)
                sys.exit()

    req.encoding = 'utf-8'
    #write to da json file :)
    with open("ss_data.json", "w") as outfile:
        outfile.write(req.text)

    print("finished running!!")

if __name__ == "__main__":

    print("started running!")

    #gets config from json and loads
    with open("apiConfig.json", "r") as openfile:
        apiConfig = json.load(openfile)

    timesteps = apiConfig["timesteps"]
    includeLocation = apiConfig["includeLocation"]
    excludeMetadata = apiConfig["excludeMetadata"]
    latitude = apiConfig["latitude"]
    longitude = apiConfig["longitude"]
    apikey = apiConfig["apikey"]

    # Client API key must be supplied
    if apikey == "":
        print("ERROR: API credentials must be supplied.")
        sys.exit()
    else:
        requestHeaders = {"apikey": apikey}

    if latitude == "" or longitude == "":
        print("ERROR: Latitude and longitude must be supplied")
        sys.exit()

    if timesteps != "hourly" and timesteps != "three-hourly" and timesteps != "daily":
        print("ERROR: The available frequencies for timesteps are hourly, three-hourly or daily.")
        sys.exit() 
    
    retrieve_forecast(base_url, timesteps, requestHeaders, latitude, longitude, excludeMetadata, includeLocation)




