| **Designator** | **Side<sup>§</sup>** | **Size** | **Part**    | **Value** | **OI<sup>†</sup>** |
|:--------------:|:---------:|:--------:|:-----------:|:---------:|:-------:|
| U1             | Front     | ----     | ----        | M41T81S   | Yes     |
| R1             | Front     | ----     | ----        | 4xResNet  | No      |
| Q3             | Front     | SOT223   | MOSFET      | IRLL024N  | Yes     |
| C1             | Front     | 603      | Cap         | 0.1uF     | No      |
| C2             | Front     | 805      | Cap         | 47uF      | No      |
| C6             | Front     | 603      | Cap         | 0.1uF     | No      |
| R2             | Front     | 603      | Resistor    | 1kOhm     | No      |
| LED            | Front     | 805      | LED         | Red       | Yes     |
| Y1             | Front     | Can      | Xtal        | 32768Hz   | No      |
|                |           |          |             |           |         |
| U2             | Back      | ----     | ATMEGA168PV | ----      | Yes     |
| D1             | Back      | 0805     | Resistor    | 100hm     | No      |
| C3             | Back      | 0603     | Cap         | 0.1uF     | No      |
| C4             | Back      | 0603     | Cap         | 0.1uF     | No      |
| C5             | Back      | 0603     | Cap         | 0.1uF     | No      |
| C8             | Back      | 0603     | Cap         | 0.1uF     | No      |

<sup>§</sup> Side = Side of board<br>
<sup>†</sup> OI = Orientation Important

| **Part**          | **Qty** | **Designators**   | **Supplier** | **Supplier PN**       | **Description**             |
|:-----------------:|:-------:|:-----------------:|:------------:|:---------------------:|:---------------------------:|
| M41T81S           | 1       | U1                | Digikey      | 497\-4684\-1\-ND      | Timer                       |
| ATMEGA168PV       | 1       | U2                | Digikey      | ATMEGA168PV\-10AU\-ND | Microcontroller             |
| IRLL024N          | 1       | Q3                | Digikey      | IRLL024NPBFCT\-ND     | N Channel MOSFET            |
| C0805C473K5RACTU  | 1       | C2                | Digikey      | 399\-1166\-1\-ND      | 47uF 0805                   |
| TC164\-JR\-0710KL | 1       | R1                | Digikey      | TC164J\-10KCT\-ND     | 4x Resistor Network 10k     |
| CFS\-20632768EZBB | 1       | Y1                | Digikey      | 300\-8761\-ND         | 32\.768kHz Xtal in Can      |
| 150080RS75000     | 1       | LED               | Digikey      | 732\-4984\-1\-ND      | Red LED 0805                |
| 1K Resistor       | 1       | R2                | Element14    | RMCF0603JT1K00CT\-ND  | Any 1K 0603 Resistor        |
| 10R Resistor      | 1       | D1                | Element14    | RNCP0805FT010R0CT\-ND | Any 5% 0805 10R Resistor    |
| 0\.1uF Cap        | 6       | C1,C3,C4,C5,C6,C8 | \-\-\-\-     | 1276\-1112\-1\-ND     | 0\.1uF 0603 Decoupling Caps |
