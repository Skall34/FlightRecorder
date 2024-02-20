# FlightRecorder
a simple flight recorder using FSUIPC client library (compatible with x-plane and MS FS)

This little tool gets data from the flight sim, and is able to send to to a google sheet, through a google form.
Thus there is a manual configuration to setup the sheet and the form :

1) Using google forms, create a new form.
2) In this form, create all the following questions, all asking for short text answers :
- Callsign
- Aircraft immat.
- Passengers
- Cargo
- Departure_ICAO
- Departure_Fuel
- Departure_Time
- Arrival_ICAO
- Arrival_Fuel
- Arrival_Time

3) In the '...' right menu, select "get link" to get a link of the form with predefined values.
4) Fill each response field with the name of the field (ex Callsign => Callsign), then click "get link" in the lower part of the form.
5) Copy the link. You should have something lokking like :
   https://docs.google.com/forms/d/e/1FAIpQLSeUruKbF7P3Es2b5JC8RIZaDhK5In1nwn_mq_RhsGV5MXU9AQ/viewform?usp=pp_url&entry.875291795=Callsign&entry.793899725=Aircraft+immat.&entry.941405603=Passengers&entry.704113444=Cargo&entry.354262163=Departure_ICAO&entry.1974689794=Departure_Fuel&entry.1603698953=Departure_Time&entry.864236608=Arrival_ICAO&entry.789000913=Arrival_Fuel&entry.1547789562=Arrival_Time

6) Past the link in the advanced setting form in the FilghtRecorder. Each field of the form should be extracted and associated to the corresponding fields in the FligheRecorder. If necessary, edit the messing entry fields manually.

7) Click the "Save & close" button to apply the new settings.
8) In the form's reponse tabs, verify that the responses go in a google sheet.
   

