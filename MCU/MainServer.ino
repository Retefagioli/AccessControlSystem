#include "Arduino.h"
#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266WebServer.h>
#include <ESP8266mDNS.h>
#include <ArduinoJson.h>

const char* ssid = "PCTO";
const char* password = "BYLedvbau69egFA";

#define ACCESS_GREEN 12
#define ACCESS_RED 2

ESP8266WebServer server(8888);

void setup() {
  Serial.begin(9600);
  initWiFi();
  pinMode(ACCESS_GREEN, OUTPUT);
  pinMode(ACCESS_RED, OUTPUT);
  restServerRouting();
  server.begin();
}


void loop() {
 server.handleClient();
}


void initWiFi()
{
  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED)
  {
    delay(500);  
    Serial.print("*");
  }
  // General info start up 
  Serial.println("\nWiFi connection successful");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());  
}

void restServerRouting()
{
  server.on("/", HTTP_GET, []() 
  {
    server.send(200, F("text/html"), F("Welcome to the REST Web Server"));
  });
  
  server.on("/api/access", HTTP_POST, accessDevice);
  
  server.onNotFound([]()
  {
      server.send(418, "text/plain", "Uri not found "+server.uri());
  });

}

void accessDevice()
{
    String postBody = server.arg("plain");
    Serial.println(postBody);
    if(postBody == "True")
    {
      server.send(200, "text/plain", "FUNZIONA YES");
      accessAllowed();
    } else {
      server.send(404, "text/plain", "Idiota");
      accessDenied();  
    }
}

void accessAllowed()
{
  digitalWrite(ACCESS_GREEN, HIGH);
  delay(3000);
  digitalWrite(ACCESS_GREEN, LOW);
}

void accessDenied()
{
  digitalWrite(ACCESS_RED, HIGH);
  delay(3000);
  digitalWrite(ACCESS_RED, LOW);
}
