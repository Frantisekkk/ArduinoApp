# ArduinoApp


--------------------------------------------
+++ This is code for the arduino circuit +++
--------------------------------------------

-- you only need button, LDR/fotoresistor 10k and 100k ohm resistor and arduino --

code:
===============================================================================

const int buttonPin = 2; // the number of the pushbutton pin
const int LDRPin = A0;   // the number of the LDR pin

// variables will change:
int buttonState = 0;         // variable for reading the pushbutton status

void setup() {
  // initialize the pushbutton pin as an input with internal pull-up resistor:
  pinMode(buttonPin, INPUT_PULLUP);
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
}

void loop() {
  // read the state of the pushbutton value:
  buttonState = digitalRead(buttonPin);

  // check if the pushbutton is pressed. If it is, the buttonState is LOW:
  if (buttonState == LOW) {
    // read the value from the LDR:
    int LDRValue = analogRead(LDRPin);
    // Convert the analog reading (which goes from 0 - 1023) to a voltage (0 - 5V):
    float voltage = LDRValue * (5.0 / 1023.0);
    // print out the value you read:
    Serial.print("LDR Value: ");
    Serial.print(LDRValue);
    Serial.print(" - Voltage: ");
    Serial.println(voltage);
  }
  delay(300); // Delay a little bit to improve simulation performance
}


===============================================================================
