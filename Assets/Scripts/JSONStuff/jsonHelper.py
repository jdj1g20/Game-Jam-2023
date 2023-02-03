from tkinter import *
import json
import os

window=Tk()
# add widgets here
# make sure to link to the narrative
# there should be a good reason for each property, events, mechanics 
# events should be responsive to properties 

properties = ['military','economy','approval','diplomacy','food']
advisors = ['militaryA','economyA','civilA','catA','foodA']
sounds = ['bearDieWithFire','happyBearNoises','ratEatingNoises','ratPainNoise',"EconomyPlus","EconomyMinus","ApprovalPlus","ApprovalMinus","MillitaryPlus","MillitaryMinus","DiplomacyPlus","DiplomacyMinus","FoodPlus","FoodMinus",""]

def callback(self, P):
    if str.isdigit(P) and int(P) >= 0 and int(P) <= 10:
        return True
    else:
        return False

def retrieve_input(textBox):
    inputValue=textBox.get("1.0","end-1c")
    return inputValue


widgets = []
labs = []
h = 1
m = 3
w = 40

description = Text(height = h*m, width=w)
labs.append(Label(text="Description"))
op1=StringVar()
advisor = OptionMenu(window,op1,*advisors)
labs.append(Label(text="Ddvisor"))
s=StringVar()
sfx = OptionMenu(window,s,*sounds)
labs.append(Label(text="sfx"))
decisionDesc = Text(height = h*m, width=w)
labs.append(Label(text="descisionDesc"))
widgets.append(description)
widgets.append(advisor)
widgets.append(sfx)
widgets.append(decisionDesc)

decision1desc = Text(height = h*m, width=w)
labs.append(Label(text="desc1Desc"))
decision1but = Text(height = h, width=w)
labs.append(Label(text="desc1Outcome"))
s11=StringVar()
stat11 = OptionMenu(window,s11,*properties)
labs.append(Label(text="stat11"))
stat11amount = Text(height = h, width=w)
labs.append(Label(text="stat11amount"))
s12 = StringVar()
stat12 = OptionMenu(window,s12,*properties)
labs.append(Label(text="stat12"))
stat12amount = Text(height = h, width=w)
labs.append(Label(text="stat12amount"))
s1 = StringVar()
sfx1 = OptionMenu(window,s1,*sounds)
labs.append(Label(text="sfx1"))
widgets.append(decision1desc)
widgets.append(decision1but)
widgets.append(stat11)
widgets.append(stat11amount)
widgets.append(stat12)
widgets.append(stat12amount)
widgets.append(sfx1)

decision2desc = Text(height = h*m, width=w)
labs.append(Label(text="desc2Desc"))
decision2but = Text(height = h, width=w)
labs.append(Label(text="desc2Outcome"))
s21 = StringVar()
stat21 = OptionMenu(window,s21,*properties)
labs.append(Label(text="stat21"))
stat21amount = Text(height = h, width=w)
labs.append(Label(text="stat21amount"))
s22 = StringVar()
stat22 = OptionMenu(window,s22,*properties)
labs.append(Label(text="stat22"))
stat22amount = Text(height = h, width=w)
labs.append(Label(text="stat22amount"))
s2 = StringVar()
sfx2 = OptionMenu(window,s2,*sounds)
labs.append(Label(text="sfx2"))
widgets.append(decision2desc)
widgets.append(decision2but)
widgets.append(stat21)
widgets.append(stat21amount)
widgets.append(stat22)
widgets.append(stat22amount)
widgets.append(sfx2)

def getJson():
    j = {
            "description": retrieve_input(description),
            "advisor":op1.get(),
            "SFX": s.get(),
            "decision1Desc": retrieve_input(decision1desc),
            "decision1": {
                "description": retrieve_input(decision1but),
                "stat1": s11.get(),
                "stat1Amount": retrieve_input(stat11amount),
                "stat2": s12.get(),
                "stat2Amount": retrieve_input(stat12amount),
                "SFX": s1.get()
            },
            "decision2Desc": retrieve_input(decision2desc),
            "decision2": {
                "description": retrieve_input(decision2but),
                "stat1": s21.get(),
                "stat1Amount": retrieve_input(stat21amount),
                "stat2": s22.get(),
                "stat2Amount": retrieve_input(stat22amount),
                "SFX": s2.get()
            }
    }
    return j

def getJsonSec():
    dirname = os.path.dirname(__file__)
    filename = os.path.join(dirname, 'secondary.json')
    temp = getJson()
    data = []
    with open(filename) as secondary0:
        data = json.load(secondary0)
    with open(filename,"w") as secondary:
        data['events'].append(temp)
        json.dump(data,secondary)

def getJsonMain():
    dirname = os.path.dirname(__file__)
    filename = os.path.join(dirname, 'primary.json')
    temp = getJson()
    data = []
    with open(filename) as prim0:
        data = json.load(prim0)
    with open(filename,"w") as prim:
        data['events'].append(temp)
        json.dump(data,prim)

sgen = Button(command=getJsonSec,text="Generate Secondary")
widgets.append(sgen)

mgen = Button(command=getJsonMain,text="Generate Main")
widgets.append(mgen)

i = 0

for w in widgets:
    w.grid(row=i,column=1)
    if(i < len(labs)):
        labs[i].grid(row=i,column=0)
    i = i + 1

window.title('Hello Python')
width= window.winfo_screenwidth()               
height= window.winfo_screenheight()               
window.geometry("%dx%d" % (width, height))
window.mainloop()



