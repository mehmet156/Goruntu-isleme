
int alinan;

void setup() {
  pinMode(2,OUTPUT);
   pinMode(3,OUTPUT);
    pinMode(4,OUTPUT);
     pinMode(5,OUTPUT);
      pinMode(6,OUTPUT);
       pinMode(7,OUTPUT);
        pinMode(8,OUTPUT);
         pinMode(9,OUTPUT);
          pinMode(10,OUTPUT);
          pinMode(13,OUTPUT);
          Serial.begin(9600);

}

void loop() {
  if (Serial.available()) { 
    
    alinan = Serial.read(); 
    Serial.print("Alinan Deger: ");
    Serial.print(alinan); 
    
  }


if(alinan=='1')
{


  digitalWrite(2,HIGH);
  digitalWrite(3,LOW);
  
  }


  else if(alinan=='2')

{
  digitalWrite(3,HIGH);
  digitalWrite(2,LOW);
  }
  
  else
  {
    digitalWrite(2,LOW);
    digitalWrite(3,LOW);
    }
 

}
