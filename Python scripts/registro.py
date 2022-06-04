# -*- coding: utf-8 -*-
"""
Created on Mon Jul  5 16:32:36 2021

@author: javi2
"""


class Registro:
    id_ = 0
    name = ""
    row = 0
      
    # parameterized constructor
    def __init__(self, i,n,r):
        self.id_ = i
        self.name = n
        self.row = r
      
    
    def calculate(self):
        print([self.id_, self.name, self.row])
  

  
# display result
#obj.display()